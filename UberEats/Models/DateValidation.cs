//using System.ComponentModel.DataAnnotations;

//namespace UberEats.Models
//{
//    public class DateValidationAttribute: ValidationAttribute
//    {
//        public override bool IsValid(object val)
//        {
//            int age = 0;
//            age = DateTime.Now.Subtract(Convert.ToDateTime(val)).Days;
//            age = age / 365;
//            if(age >= 18)
//            {
//                return false;
//            }
//            return true;

//        }
//    }
//}
