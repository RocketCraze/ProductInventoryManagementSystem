namespace ProductInventoryManagementSystem.Data
{
    public class EnumTypes
    {
        public int ID { get; set; }

        public string Type { get; set; }
    }

    public static class Types
    {
        public static readonly List<EnumTypes> Type = new List<EnumTypes>
        {
            new EnumTypes {
                ID = 1,
                Type = "Single-Engine"
            },

            new EnumTypes {
                ID = 2,
                Type = "Multi-Engine"
            },

            new EnumTypes
            {
                ID = 3,
                Type = "Rotorcraft"
            }
        };
    }
}
