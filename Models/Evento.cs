using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TW.Models
{
    [Table("evento")]
    public partial class Evento
    {
        [Key]
        [Column("id_evento")]
        public int IdEvento { get; set; }
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("data_evento", TypeName = "date")]
        public DateTime? DataEvento { get; set; }
        [Column("localizacao")]
        [StringLength(50)]
        public string Localizacao { get; set; }
        [Column("hora", TypeName = "datetime")]
        public DateTime? Hora { get; set; }
        [Column("descricao")]
        [StringLength(200)]
        public string Descricao { get; set; }
        [Column("sala")]
        [MaxLength(1)]
        public byte[] Sala { get; set; }
        [Column("interprete")]
        [MaxLength(1)]
        public byte[] Interprete { get; set; }
        [Column("alimentaçao")]
        [MaxLength(1)]
        public byte[] Alimentaçao { get; set; }
        [Column("id_comunidade")]
        public int? IdComunidade { get; set; }
        [Column("id_categoria")]
        public int? IdCategoria { get; set; }
        [Column("id_adm")]
        public int? IdAdm { get; set; }

        [ForeignKey(nameof(IdAdm))]
        [InverseProperty(nameof(TblAdm.Evento))]
        public virtual TblAdm IdAdmNavigation { get; set; }
        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categoria.Evento))]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdComunidade))]
        [InverseProperty(nameof(TblComunidade.Evento))]
        public virtual TblComunidade IdComunidadeNavigation { get; set; }
    }
}
