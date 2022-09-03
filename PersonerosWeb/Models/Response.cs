using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonerosWeb.Models {
    public class Response<TEntity> {
        public bool success { get; set; }
        public TEntity result { get; set; }
        public string displayMessage { get; set; }
        public List<string> errorMessage { get; set; }

        public Response<TEntity> createErrorResponse(string displayMessage, List<string> errorMessage) {
            success = false;
            result = default(TEntity);
            this.displayMessage = displayMessage;
            this.errorMessage = errorMessage;
            return this;
        }

    }
}