using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOfMemes
{
    class ContextInitializer : DropCreateDatabaseIfModelChanges<ContextOfMemes>
    {
        protected override void Seed(ContextOfMemes context)
        {

            base.Seed(context);
        }
    }
}
