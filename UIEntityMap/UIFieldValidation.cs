using System;
using System.Linq;
using Utility;

namespace UIEntityMap
{
    public class UIFieldValidation
    {
        public enum ReturnCodes
        {
            INPUT_VALID,
            REQUIRED_FIELD_EMPTY,
            INVALID_NON_NEGATIVE_DECIMAL
        }

        public enum ValidationClass
        {
            GENERAL_VALIDATION,
            FORMAT_VALIDATION
        }

        public class UIFieldValidationResult
        {
            public string StrPropertyName { get; private set; }
            public object[] ObjInputs { get; private set; }
            public ReturnCodes ReturnCode { get; private set; }

            public UIFieldValidationResult(string strPropertyName, object[] objInputs, ReturnCodes returnCode)
            {
                StrPropertyName = strPropertyName;
                ObjInputs = objInputs;
                ReturnCode = returnCode;
            }
        }

        public class UIFieldValidators
        {

            internal static readonly UIFieldValidators IsNotEmptyString = new UIFieldValidators(new Predicate<object[]>(x => x.All(y => !string.IsNullOrWhiteSpace(y.ToString()))));
            internal static readonly UIFieldValidators IsValidDecimal = new UIFieldValidators(new Predicate<object[]>(x => x.All(y => decimal.TryParse(y.ToString(), out _))));
            internal static readonly UIFieldValidators IsNonNegativeNumeric = new UIFieldValidators(new Predicate<object[]>(x => x.All(y => decimal.TryParse(y.ToString(), out decimal result) && result >= 0)));

            public Predicate<object[]> PredicateValidator { get; private set; }

            private UIFieldValidators(Predicate<object[]> predicateValidator)
            {
                PredicateValidator = predicateValidator;
            }
        }

        public static readonly UIFieldValidation RequiredFieldValidation = new UIFieldValidation(new UIFieldValidators[] { UIFieldValidators.IsNotEmptyString }, ValidationClass.GENERAL_VALIDATION, ReturnCodes.REQUIRED_FIELD_EMPTY, "errorRequiredCompulsoryFieldsHeading");
        public static readonly UIFieldValidation NonNegativeDecimalFieldValidation = new UIFieldValidation(new UIFieldValidators[] { UIFieldValidators.IsValidDecimal, UIFieldValidators.IsNonNegativeNumeric }, ValidationClass.FORMAT_VALIDATION, ReturnCodes.INVALID_NON_NEGATIVE_DECIMAL, "errorFieldInvalidNumeric");

        public UIFieldValidators[] Validators { get; private  set; }
        public ValidationClass VCValidationClass { get; private set; }
        public ReturnCodes InvalidReturnCode { get; private set; }
        public string StrErrorPromptResxKey { get;  private set; }
        public string StrErrorPromptDispText { get { return ResxManager.ResourceManager.GetString(StrErrorPromptResxKey); } }

        public UIFieldValidation(UIFieldValidators[] validators, ValidationClass vcValidationClass, ReturnCodes invalidReturnCode, string strErrorPromptResxKey)
        {
            Validators = validators;
            VCValidationClass = vcValidationClass;
            InvalidReturnCode = invalidReturnCode;
            StrErrorPromptResxKey = strErrorPromptResxKey;
        }

        public UIFieldValidationResult Validate(string strPropertyName, object[] objInputs)
        {
            return new UIFieldValidationResult(strPropertyName, objInputs, (Validators.All(x => x.PredicateValidator(objInputs)) ? ReturnCodes.INPUT_VALID : InvalidReturnCode));
        }
    }
}
