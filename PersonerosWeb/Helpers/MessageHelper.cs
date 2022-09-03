using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonerosWeb.Helpers {
    public class MessageHelper {
        public bool ok { get; set; }
        public string msg { get; set; }

        public MessageHelper(bool _ok, string _msg) {
            this.ok = _ok;
            this.msg = _msg;
        }

        public MessageHelper() {
        }
    }
}