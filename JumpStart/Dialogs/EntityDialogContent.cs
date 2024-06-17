using JumpStart.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Dialogs;
public class EntityDialogContent<TEntity> where TEntity : Entity
{
    public TEntity Entity { get; set; }

    public IServiceProvider ServiceProvider { get; set; }
}
