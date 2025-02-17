using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AI.AgentFramework.Interfaces
{
    public interface ITool
    {
        Task<string> ExecuteAsync(Context context, string input);
    }

}
