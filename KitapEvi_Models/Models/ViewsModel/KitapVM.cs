﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapEvi_Models.Models.ViewsModel
{
   public class KitapVM
    {
        public Kitap Kitap { get; set; }
        public IEnumerable<SelectListItem> KategoriListe { get; set; }

        public IEnumerable<SelectListItem> YayinEviListesi { get; set; }
    }
}
