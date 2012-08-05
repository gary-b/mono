# fix-xdb.py

# Script to restructure the Apple assembly file generated for XDEBUG support.
# This will reorganize the sections and subsections in order.

import sys
import re
from collections import defaultdict

def read_file(filename):
	try:
		with open(filename, 'r') as openfile:
			contents = openfile.readlines() 
	except IOError as e:
		print 'Unable to open file specified'
		sys.exit()

	return contents

def close_file(inputbuffer):
	inputbuffer.append('.section __DWARF, __debug_info,regular,debug\n')
	inputbuffer.append('\n')
	inputbuffer.append('	.byte 0\n')
	inputbuffer.append('Ldebug_info_end:\n')
	inputbuffer.append('\n')

	return inputbuffer

def parse_file(inputbuffer):
	# Outer dictionary is for sections; sub-dictionaries for subsections
	unsortedlines = defaultdict(lambda : defaultdict(lambda : list()))
	sectionorder = list()
	currentsection = ''
	currentsubsection = 0

	for line in inputbuffer:
		if line.startswith('#APPLE_SECTION_MARKER'):
			match = re.match(r'\#APPLE_SECTION_MARKER: (.*);(.*)', line)
			currentsection = match.group(1)
			currentsubsection = int(match.group(2))
			
			if not currentsection in sectionorder:
				sectionorder.append(currentsection)
		else:
			unsortedlines[currentsection][currentsubsection].append(line)	

	return (unsortedlines, sectionorder)

def reorder_file(unsortedlines, sectionorder):
	sortedlines = list()

	for section in sectionorder:
		subsections = sorted(unsortedlines[section].keys())
		for subsection in subsections:
			sortedlines += unsortedlines[section][subsection]

	return sortedlines

def output_file(sortedlines):
	try:
		with open('xdb-fixed.s', 'w') as openfile:
			for line in sortedlines:
				openfile.write(line) 
	except IOError as e:
		print 'Unable to write to xdb-reorg.s'
		sys.exit()
	
	return


if (len(sys.argv) > 1):
	closefile = 'close' in sys.argv
	filename = sys.argv[-1]
else:
	print 'Please specify a file name'
	sys.exit()

inputbuffer = read_file(filename)
if closefile:
	inputbuffer = close_file(inputbuffer)
unsortedinput = parse_file(inputbuffer)
sortedlines = reorder_file(unsortedinput[0], unsortedinput[1])
output_file(sortedlines)
