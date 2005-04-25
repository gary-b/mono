//
// System.Security.Policy.ApplicationTrust class
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2004-2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NET_2_0

using System.Runtime.InteropServices;

namespace System.Security.Policy {

	[ComVisible (true)]
	public sealed class ApplicationTrust : ISecurityEncodable {

		private ApplicationIdentity _appid;
		private PolicyStatement _defaultPolicy;
		private object _xtranfo;
		private bool _trustrun;
		private bool _persist;

		[MonoTODO]
		public ApplicationTrust ()
		{
		}

		[MonoTODO]
		public ApplicationTrust (ApplicationIdentity applicationIdentity)
			: this ()
		{
		}

		public ApplicationIdentity ApplicationIdentity {
			get { return _appid; }
		}

		public PolicyStatement DefaultGrantSet {
			get { return _defaultPolicy; }
			set { _defaultPolicy = value; }
		}

		public object ExtraInfo {
			get { return _xtranfo; }
			set { _xtranfo = value; }
		}

		public bool IsApplicationTrustedToRun {
			get { return _trustrun; }
			set { _trustrun = value; }
		}

		public bool Persist {
			get { return _persist; }
			set { _persist = value; }
		}

		[MonoTODO ("incomplete")]
		public void FromXml (SecurityElement element) 
		{
			if (element == null)
				throw new ArgumentNullException ("element");
			throw new NotImplementedException ();
		}

		[MonoTODO ("incomplete")]
		public SecurityElement ToXml () 
		{
			throw new NotImplementedException ();
		}
	}
}

#endif
