
namespace HW_5_Klyushin
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using HW_5_Klyushin.Annotations;

    [Serializable]

    /// <summary>
    /// Human class
    /// </summary>
    public class Human : INotifyPropertyChanged
    {
        private string name;

        private string lastname;

        private string surname;

        private DateTime birthDay;

        private string sex;
        /// <summary>
        /// Initializes a new instance of the <see cref="Human"/> class
        /// </summary>
        public Human()
        {
            this.name = String.Empty;
            this.lastname = String.Empty;
            this.surname = String.Empty;
            this.birthDay = new DateTime();
            this.sex = String.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Human"/> class
        /// </summary>
        /// <param name="name">Human name</param>
        /// <param name="lastname">Human lastname</param>
        /// <param name="surname">Human surname</param>
        /// <param name="humanSex">Human sex</param>
        /// <param name="birthDay">Human birthday</param>
        public Human(string name, string lastname, string surname, Enum humanSex, DateTime birthDay)
        {
            this.name = name;
            this.lastname = lastname;
            this.surname = surname;
            this.birthDay = birthDay;
            this.sex = humanSex.Equals(Human.humanSex.Male) ? "М" : "Ж";
        }

        /// <summary>
        /// The sex of human
        /// </summary>
        public enum humanSex
        {
            Male,
            Female
        };

        /// <summary>
        /// Gets human name
        /// </summary>
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        /// <summary>
        /// Gets human lastname
        /// </summary>
        public string Lastname
        {
            get => this.lastname;
            set
            {
                this.lastname = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Lastname)));
            }
        }

        /// <summary>
        /// Gets human surname
        /// </summary>
        public string Surname
        {
            get => this.surname;
            set
            {
                this.surname = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Surname)));
            }
        }

        /// <summary>
        /// Gets human birthday
        /// </summary>
        public DateTime BirthDay
        {
            get => this.birthDay;
            set
            {
                this.birthDay = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.BirthDay)));
            }
        }

        /// <summary>
        /// Human sex
        /// </summary>
        public string Sex
        {
            get => this.sex;
            set
            {
                this.sex = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Sex)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
