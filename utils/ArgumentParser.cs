using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Store {
    public enum ECommands
    {
        install,
        unistall,
        update,
        backup,
        export,
        import,
        doctor,
        none
    }
    internal class ArgumentParser {
        public static ECommands Parse(String[] args) {
            if (Enum.TryParse<ECommands>(args[0], out ECommands e)){
                return e;
            }
            return ECommands.none;
        }
    }
}
