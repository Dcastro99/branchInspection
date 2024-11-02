
using genscoSQLProject1.Dto;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.SeedData
{
    public static class ChecklistItemsData
    {
        public static List<ChecklistItem> GetChecklistItems()
        {
            return new List<ChecklistItem>
            {
                new ChecklistItemBuilder("Posting should be in an area accessible to all Team Members, (e.g. - lunch room, time clock station,etc.)", 1)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("State and Federal Law Posters", 1)
                    .SetIsCheckedNeeded(true)
                    .SetStatePosterDatePostedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("OSHA 300A Log (Post Feb. 1 - Apr. 30th. Keep last 5 years on file)", 1)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Emergency Telephone Numbers Posted", 1)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Numbers/Employees NOT Current", 1)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Emergency Evacuation Plan/Procedure Posted", 1)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Layout NOT Current", 1)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Monthly Safety Meeting Minutes (Keep last 12 months on file)", 2)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Fall Protection Plan Posted", 2)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Plan NOT Current", 2)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Monthly Safety Meeting with ALL team members:", 2)
                    .SetIsCheckedNeeded(true)
                    .SetSafetyLastMeetingDateNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Gensco's Safety and Accident Prevention Plan is available to all team members", 2)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Team members know where it is located", 2)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Team members know how to report an unsafe working condition", 2)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("First Aid kits are easily accessible to each work area", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("First Aid kits are stocked with supplies", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("EXPIRED Medication/Supplies", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Blood Borne Pathogen kits available (unopened)", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Needs to be replaced", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Eye wash station(s) in areas where caustic / corrosive liquids/materials are handled", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Within a 10 second unobstructed walk", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Eye wash station(s) cartridge(s) are not expired (Uline Part# S-11507, 24-month Cartridge Life)", 3)
                    .SetIsCheckedNeeded(true)
                    .SetDateCartridgeNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("KN95 masks are available for employees", 3)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Team Members know what SDS (Safety Data Sheets) are and what they are used for", 4)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                         new ChecklistItemBuilder("Signs posted with instructions to access MSDSonline through GenscoTeam.com", 4)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Fire Alarm system properly maintained and tested regularly", 5)
                    .SetIsCheckedNeeded(true)
                    .SetFireAlarmDateTestedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Sprinkler System tested annually (Sprinkler Riser)", 5)
                    .SetIsCheckedNeeded(true)
                    .SetSprinklerSystemDateTestedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Sprinkler heads protected by metal guards when exposed to potential physical damage", 5)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Proper clearance maintained below sprinkler heads (Minimum clearance of 18\")", 5)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Fire Extinguishers located in readily accessible locations and properly marked", 5)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Fire Extinguishers inspected monthly (Initial and date the tag at inspection)", 5)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Fire Extinguishers NOT inspected are identified on the Fire Extinguisher Checklist", 5)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Defective Fire Extinguishers are removed and replaced immediately", 5)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Security Alarm maintained regularly", 5)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .SetSecurityAlarmDateTestedNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("All team members know where to meet in the case of an emergency", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("All exits are marked with an exit sign and is illuminated (Test all signs with battery backup monthly)", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                      new ChecklistItemBuilder("Exit signs requiring batteries to be replaced are identified on the Fire Extinguisher Checklist", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Exit doors are able to open from the direction of exit travel without the use of a key or tool", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("All exits are kept free of obstruction (Allow 36\" wide for pathway to exit at all times)", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Doors that swing both directions between areas with frequent traffic are provided with viewing panels", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Doors, Passageways, or Stairways that are NOT exits but could be mistaken for one are appropriately marked \"NOT AN EXIT\" or are labeled what they are, e.g. - \"STOREROOM\", \"ELECTRICAL\", etc.", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Direction to Exits, if not immediately apparent, are marked with visible signs", 6)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Load Capacity of mezzanine is clearly Marked", 7)
                    .SetIsCheckedNeeded(true)
                    .SetloadCapacityNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Standard guardrails provided on surfaces 4' or more above the ground", 7)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Toe boards installed on openings on elevated surfaces", 7)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Dock boards or bridge plates are used and secured between docks and trucks", 7)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Visual barriers for loading docks if doors are left open with NO truck backed in", 7)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Aisles and passageways kept clear and at least 28\" wide", 8)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Equipment and material stored so sharp objects cannot obstruct walkways", 8)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Adequate headroom (at least 7 feet) provided for entire length of walkways/stairs", 8)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Floors are free of holes, projections, or depressions that could cause trips or let material fall below", 8)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Standard guardrails provided wherever surfaces are elevated more than 4 feet", 8)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Guardrails 36\"-42\" high are capable of withstanding 200 lbs of force in any direction", 8)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Toe boards installed to prevent debris from falling below", 8)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Cylinders located and/or stored in protected areas (covered from above)", 9)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Cylinders transported in a manner to prevent them from rolling, tipping, or falling", 9)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Valve protector placed on cylinders when not in use (125 lbs cylinders)", 9)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Acetylene and Oxygen cylinders MUST be stored a minimum of 20 feet apart", 9)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                 new ChecklistItemBuilder("Cylinders legibly marked to clearly identify the contents as FULL or EMPTY", 9)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming this is implemented in your builder
                    .Build(),

                new ChecklistItemBuilder("Breaker boxes are kept clear and can be accessed when needed", 10)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Look at electrical panel(s) and check to make sure they are not hot", 10)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Extension cords are ONLY used for temporary use, NOT a permanent source of power", 10)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Extension cords MUST contain a ground (3-wire) or are marked as double insulated and in good repair", 10)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Extension cords and surge protectors are NOT to be connected together to obtain more power outlets", 10)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Proper storage methods used to minimize risk of fire", 11)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Safe practices followed when liquid petroleum (LP) gas is stored, handled, and used", 11)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Liquid petroleum (LP) storage tanks guarded to prevent damage", 11)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("\"NO SMOKING\" signs posted in areas where flammable materials are stored", 11)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("PPE inspected daily for damage and wear (gloves, harnesses, lanyards, etc.)", 12)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Gloves worn at all times when handling product or operating MHE", 12)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Protective goggles or face shields provided and worn when there is any danger of flying materials", 12)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Ear protection is provided and used in areas where it is necessary to raise your voice to be heard", 12)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Team Members have been trained on how to use all tools provided", 13)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("All safe guards are in good repair", 13)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Broken hand tools and power tools are discarded and replaced promptly", 13)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("All ladders are securely stored", 14)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Non-slip safety feet on all ladders", 14)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("All ladders are in good condition with no missing parts (Defective ladders will be replaced immediately)", 14)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Ladder rungs and steps are free of grease and oil", 14)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Top step on ladder NOT to be used as a step", 14)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Ladders cannot be placed on boxes, or other items, to obtain additional height", 14)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Safe clearances for equipment through aisles and doorways", 15)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Empty pallets are not to be stacked more than 20 high and must be staged on the floor", 15)
                    .SetIsCheckedNeeded(true)
                    .Build(),
                 new ChecklistItemBuilder("Pallets inspected before loading or moving", 15)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Hand trucks maintained in good condition (Defective hand trucks to be discarded and replaced)", 15)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Wheel chocks are provided for each dock door and used while loading/unloading trucks and trailers", 15)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Dock boards/plates are used while loading/unloading between vehicles and docks", 15)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Load capacity signs are posted and accurate for each aisle", 16)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Load on shelves DO NOT exceed the capacity of the beams", 16)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Load beams are free from damage and are using proper locking mechanisms", 16)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Uprights are free from damage with at least 2 floor bolts per foot and installed in the proper orientation", 16)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Cantilever is free from damage with containment device on each level (e.g. - chains, extended pins)", 16)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Product reside within the staging zones (NOT overflowing into main aisles)", 17)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Product does NOT lean into aisles, over racking, or over the marked staging lines", 17)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Open box tops are cut off (With the EXCEPTION of air filters)", 17)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Boxes containing new product are undamaged", 17)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Product is stacked with no danger of falling or collapsing", 17)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Product is NOT stacked too high or in places where team members cannot safely stock/pull product", 17)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Literature wall/section is organized and stock is replenished regularly", 18)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Equipment display is clean, appealing, and containing relevant literature for the display", 18)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Supplies display is clean, appealing, and containing relevant literature for the display", 18)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Gensco catalogs are readily available to customers", 18)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Monthly chronicle is displayed in a neat orderly fashion, and is current", 18)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Old banners, displays, and clutter are not present in the showroom", 18)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("", 19)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Product on shelves are clean and organized", 19)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("ISR stations and back counter are clean and organized", 19)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Coffee station is clean and sanitary", 19)
                    .SetIsCheckedNeeded(true)
                    .Build(),
                        new ChecklistItemBuilder("Sink is free of leaks", 19)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Carpet is free from stains and damage", 20)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Tables, chairs, and other office furniture is in good condition", 20)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Floors, counters, furniture, and cabinets are clean", 21)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Refrigerator is clean, organized, and does NOT contain outdated or Spoiled food", 21)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Microwave is cleaned regularly", 21)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Oven is cleaned regularly and does NOT have built up baked-on food", 21)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Sink is free of leaks", 21)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Workstations are kept clean and organized", 22)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Empty pallets are not left in stocking locations", 22)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Floors are clear of debris", 22)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Parking lot is kept clean and clear of debris", 23)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Pallets, cradles, and skids are organized", 23)
                    .SetIsCheckedNeeded(true)
                    .SetNotApplicableNeeded(true) // Assuming SetNotApplicable method exists
                    .Build(),

                new ChecklistItemBuilder("No weeds or vegetation within 15 ft of items stored outside", 23)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Landscaping is maintained regularly to make building presentable", 23)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("All Operators are certified to operate respective MHE and documentation is on file", 24)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("All team members use fall protection, fall protection is in good condition, and is less than 5 years old", 24)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Team members inspect MHE prior to use each day and/or shift", 24)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Batteries are charged in a well ventilated area free of combustible material", 24)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Spill kit is available to clean up hazardous material", 24)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Inspected Daily", 25)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Horn is operational", 25)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Seat belt is in good condition", 25)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Load capacity chart is legible", 25)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Batteries are watered regularly", 25)
                    .SetIsCheckedNeeded(true)
                    .Build(),
                         new ChecklistItemBuilder("Paint and appearance is in good condition", 25)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Inspected Daily", 26)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Horn is operational", 26)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Lanyard is in good condition", 26)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Load capacity chart is legible", 26)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Batteries are watered regularly", 26)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Paint and appearance is in good condition", 26)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Inspected regularly", 27)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Maintained regularly", 27)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Appearance is in good condition", 27)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Interior/Exterior is in good condition", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Wind shield is free of cracks or chips", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Bumpers and step downs are treated with slip-resistant tape or paint", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Wide turn stickers are on rear roll-up door", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("DOT Annual Vehicle Inspection Date", 28)
                    .SetIsCheckedNeeded(true)
                    .SetDotInspectionDateNeeded(true) // Assuming SetDotInspectionDateNeeded method exists
                    .Build(),

                new ChecklistItemBuilder("Current registration for vehicle", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Current year's insurance information", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("DOT UA Chain of Custody form (CDL vehicles ONLY)", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Truck box height sticker in cab", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Phone mount", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Dashcam connected and properly placed", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Cell control present and connected", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Buckled in storage", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("ResQme tool", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Pre-trip inspections completed daily", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Hours of service log (Manually)", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Hours of service log (ELD)", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Fire extinguisher present and checked monthly", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("First aid kit", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Blood borne pathogen kit (unused)", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Emergency roadside reflectors", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Hard hat", 28)
                    .SetIsCheckedNeeded(true)
                    .Build(),

                new ChecklistItemBuilder("Reflective vest", 28)
                    .SetIsCheckedNeeded(true)
                    .Build()

            };
        }
    }
}


