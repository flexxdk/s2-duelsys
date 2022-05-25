using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using BLL.Validation;

namespace BLL.Registries
{
    public abstract class BaseRegistry
    {
        public BaseRegistry() { }

        protected void ValidateModel(object model)
        {
            IEnumerable<string> errors = Validate.AsModel(model);
            if (errors.Any())
            {
                throw new ValidationException(BuildError(errors));
            }
        }

        protected void ValidateModel(object model, IEnumerable<string> pregenerated)
        {
            IEnumerable<string> errors = Validate.AsModel(model).Concat(pregenerated);
            if (errors.Any())
            {
                throw new ValidationException(BuildError(errors));
            }
        }

        private string BuildError(IEnumerable<string> errors)
        {
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.AppendLine("The following errors have occurred: ");
            foreach (string error in errors)
            {
                sbMessage.Append("- ");
                sbMessage.AppendLine(error);
            }
            return sbMessage.ToString();
        }
    }
}
