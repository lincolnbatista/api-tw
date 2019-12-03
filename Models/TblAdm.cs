using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TW.Models
{
    [Table("tbl_adm")]
    public partial class TblAdm
    {
        public TblAdm()
        {
            Evento = new HashSet<Evento>();
        }

        [Key]
        [Column("id_adm")]
        public int IdAdm { get; set; }
        [Column("email_adm")]
        [StringLength(50)]
        public string EmailAdm { get; set; }
        [Column("senha")]
        [StringLength(50)]
        public string Senha { get; set; }
        [Column("tipo_usuario")]
        [MaxLength(1)]
        public byte[] TipoUsuario { get; set; }

        [InverseProperty("IdAdmNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
    }
}
