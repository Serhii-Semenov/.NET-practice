//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLevel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
