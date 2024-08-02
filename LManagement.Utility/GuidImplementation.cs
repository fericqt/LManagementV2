using LManagement.Utility.IUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Utility {
    public class GuidImplementation : IGuid {
        private Guid _guid { get; set; }

        public GuidImplementation()
        {
            _guid = Guid.NewGuid();
        }


        public Guid GetGuid() {
            return _guid;
        }

    }
}
