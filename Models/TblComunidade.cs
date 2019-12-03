using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TW.Models
{
    [Table("tbl_comunidade")]
    public partial class TblComunidade
    {
        public TblComunidade()
        {
            Evento = new HashSet<Evento>();
        }

        [Key]
        [Column("id_comunidade")]
        public int IdComunidade { get; set; }
        [Column("nome_comunidade")]
        [StringLength(50)]
        public string NomeComunidade { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("nome_responsavel")]
        [StringLength(50)]
        public string NomeResponsavel { get; set; }

        [InverseProperty("IdComunidadeNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
    }
}
