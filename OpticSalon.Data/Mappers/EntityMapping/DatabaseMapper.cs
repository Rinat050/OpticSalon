using OpticSalon.Data.Models;
using OpticSalon.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace OpticSalon.Data.Mappers.EntityMapping
{
    [Mapper]
    public sealed partial class DatabaseMapper
    {
        public partial Client Map(ClientDb clientDb);
        public partial ClientDb Map(Client client);
        public partial FrameType Map(FrameTypeDb frameTypeDb);
        public partial FrameTypeDb Map(FrameType frameType);
        public partial FrameMaterial Map(FrameMaterialDb frameMaterialDb);
        public partial FrameMaterialDb Map(FrameMaterial frameMaterial);
        public partial Color Map(ColorDb colorDb);
        public partial ColorDb Map(Color color);
        public partial Brand Map(BrandDb brandDb);
        public partial BrandDb Map(Brand brand);
        public partial Defect Map(DefectDb defectDb);
        public partial DefectDb Map(Defect defect);
        public partial Gender Map(GenderDb genderDb);
        public partial GenderDb Map(Gender gender);
        public partial Purpose Map(PurposeDb purposeDb);
        public partial PurposeDb Map(Purpose purpose);
        public partial Employee Map(EmployeeDb employeeDb);
        public partial EmployeeDb Map(Employee employee);
        public partial LensPackage Map(LensPackageDb lensPackageDb);
        public partial LensPackageDb Map(LensPackage lensPackage);
        public partial ClientPreferences Map(ClientPreferencesDb clientPreferencesDb);
      
        [MapperIgnoreTarget(nameof(ClientPreferencesDb.FrameType))]
        [MapperIgnoreTarget(nameof(ClientPreferencesDb.FrameColor))]
        [MapperIgnoreTarget(nameof(ClientPreferencesDb.FrameMaterial))]
        public partial ClientPreferencesDb Map(ClientPreferences clientPreferences);
        public partial FrameShort MapFrameShort(FrameDb frameDb);
        public partial Frame MapFrame(FrameDb frameDb);
        public partial Order MapOrder(OrderDb orderDb);
        [MapperIgnoreTarget(nameof(OrderDb.Frame))]
        [MapperIgnoreTarget(nameof(OrderDb.Client))]
        [MapperIgnoreTarget(nameof(OrderDb.FrameColor))]
        [MapperIgnoreTarget(nameof(OrderDb.LensPackage))]
        [MapperIgnoreTarget(nameof(OrderDb.Master))]
        public partial OrderDb Map(Order order);
        [MapperIgnoreTarget(nameof(WarrantyRepairDb.Defect))]
        [MapperIgnoreTarget(nameof(WarrantyRepairDb.Order))]
        [MapperIgnoreTarget(nameof(WarrantyRepairDb.Master))]
        [MapperIgnoreTarget(nameof(WarrantyRepairWorkDb.WarrantyRepair))]
        [MapperIgnoreTarget(nameof(WarrantyRepairWorkDb.RepairWork))]
        public partial WarrantyRepairDb Map(WarrantyRepair repair);
        public partial WarrantyRepair Map(WarrantyRepairDb repairDb);
        public partial WarrantyRepairForClient MapRepairForClient(WarrantyRepairDb repairDb);
        public partial OrderShortForClient MapOrderShort(OrderDb orderDb);
    }
}
