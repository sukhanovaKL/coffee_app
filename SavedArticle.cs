//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace coffee_app
{
    using System;
    using System.Collections.Generic;
    
    public partial class SavedArticle
    {
        public int id { get; set; }
        public Nullable<System.Guid> idGuidUser { get; set; }
        public Nullable<System.Guid> idGuidArticle { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Users Users { get; set; }
    }
}