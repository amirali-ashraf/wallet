// <auto-generated />
namespace Wallet.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddUserIdToTransaction : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddUserIdToTransaction));
        
        string IMigrationMetadata.Id
        {
            get { return "201805021123284_AddUserIdToTransaction"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
