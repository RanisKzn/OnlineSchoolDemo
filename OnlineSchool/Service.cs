//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineSchool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.Record = new HashSet<Record>();
        }
    
        public int SericeId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Duration { get; set; }
        public string MainPhoto { get; set; }
        public byte[] AdditionallyPhotos { get; set; }
        public Nullable<int> DurationTypeId { get; set; }

        public string DisplayPhoto { 
            get
            {
                if(!string.IsNullOrEmpty(this.MainPhoto))
                    return "../Resources/" + this.MainPhoto;
                return "";
            }
        }

        public string StrikethroughCost
        { 
            get
            {
                if(this.Amount is Nullable<int>)
                {
                    return this.Cost.ToString();
                }
                return "";
            } 
        }

        public string DisplayAmount
        { 
            get
            {
                if(this.Amount is Nullable<int>)
                {
                    return $"Скидка {this.Amount}";
                }
                return "";
            } 
        }

        public string DisplayColor
        { 
            get
            {
                if(this.Amount is Nullable<int>)
                {
                    return $"LightGreen";
                }
                return "Transparent";
            } 
        }

        public string DisplayCost
        { 
            get
            {

                if(DurationTypeId == 2)
                {
                    var duration = Convert.ToInt32(this.Duration);
                    this.Duration = (duration / 60).ToString();
                }
                if(this.Amount is Nullable<int>)
                {
                    return $"{this.Cost - ((this.Cost / 100) * this.Amount)} рублей за {this.Duration} минут".ToString();
                }
                else
                {
                    return $"{this.Cost} рублей за {this.Duration} минут".ToString();
                }
                return "";
            } 
        }


        public virtual DurationType DurationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Record> Record { get; set; }
    }
}
