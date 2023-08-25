using System.ComponentModel;

namespace api.Enums
{
    public enum TaskStatus
    {
        [Description("A fazer")]
        ToDo = 1,
        [Description("Em andamento")]
        Doing = 2,
        [Description("Concluido")]
        Done = 3
    }
}
