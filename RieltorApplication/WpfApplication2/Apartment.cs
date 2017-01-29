//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RieltorApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Apartment
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int TypeId { get; set; }
        public Nullable<int> SubwayId { get; set; }
        public string Name { get; set; }
        public int Square { get; set; }
        public Nullable<int> SquareLiving { get; set; }
        public Nullable<int> SquareKitchen { get; set; }
        public short Floor { get; set; }
        public bool Elevator { get; set; }
        public int Price { get; set; }
        public Nullable<int> toSubway { get; set; }
        public bool Improvment { get; set; }
        public bool Parking { get; set; }
        public short Rooms { get; set; }
    
        public virtual Region Region { get; set; }
        public virtual Subway Subway { get; set; }
        public virtual Type Type { get; set; }
    }
}
