using NPoco;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace dfEvents.DataAccess
{
    [ExcludeFromCodeCoverage]
    [TableName("Users")]
    [PrimaryKey("UserId", AutoIncrement = true)]
    public class UserEntity
    {
        public int UserId { get; set; }
        public string UserIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
