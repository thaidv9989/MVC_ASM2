using System.ComponentModel;
namespace NET_Core_2.Models
{
    public class PersonModel 
    {
        public int ID { get; set;}

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public string? Gender {get; set;}

        public DateTime DOB {get; set;}

        public string PhoneNumber {get; set;}

        public string Address {get; set;}

        public int Age {
            get{
                return DateTime.Now.Year - DOB.Year;
            }
        }

        public bool IsGraduated {get; set;}

        

        public int TotalDays{
            get{
                return (int)(DateTime.Now - DOB).TotalDays;
            }
        }

        public int CompareTo(object? obj){
            return TotalDays.CompareTo(((PersonModel)obj).TotalDays);
        }

        public string FullName{
            get{
                return $"{LastName} {FirstName}";
            }
        }
    }
}

    