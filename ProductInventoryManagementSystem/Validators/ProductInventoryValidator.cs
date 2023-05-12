namespace ProductInventoryManagementSystem.Validators
{
    using FluentValidation;
    using ProductInventoryManagementSystem.Models;

    public class ProductInventoryValidator : AbstractValidator<ProductInventory>
    {
        public ProductInventoryValidator() 
        {
            this.RuleSet("Create", () =>
            {
                this.GeneralRules();
            });

            this.RuleSet("Update", () =>
            {
                this.GeneralRules();
            });

            this.RuleSet("Delete", () =>
            {
                this.RuleFor(_ => _.ProductID)
                    .NotNull()
                    .WithMessage("ProductID cannot be null")
                    .GreaterThan(0)
                    .WithMessage("ProductID cannot be 0 or less");
            });
        }

        private void GeneralRules()
        {
            this.RuleFor(_ => _.Make)
                .NotNull()
                .MinimumLength(1)
                .WithMessage("Make cannot be empty")
                .MaximumLength(50)
                .WithMessage("Make cannot contain more than 50 characters");

            this.RuleFor(_ => _.Model)
                .NotNull()
                .MinimumLength(1)
                .WithMessage("Model cannot be empty")
                .MaximumLength(50)
                .WithMessage("Model cannot contain more than 50 characters");

            this.RuleFor(_ => _.Description)
                .NotNull()
                .MinimumLength(1)
                .WithMessage("Description cannot be empty");

            this.RuleFor(_ => _.Type)
                .NotNull()
                .MinimumLength(1)
                .WithMessage("Please select a type")
                .MaximumLength(50)
                .WithMessage("Type cannot contain more than 50 characters");

            this.RuleFor(_ => _.Price)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Price must be larger than 0");

            this.RuleFor(_ => _.Quantity)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity cannot be less than 0");
        }
    }
}
