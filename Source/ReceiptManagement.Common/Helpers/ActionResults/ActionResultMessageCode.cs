
namespace ReceiptManagement.Common.Helpers
{
    /// <summary>
    ///     The allowed types of ActionResultMessageCodes.
    /// </summary>
    public enum ActionResultMessageCode
    {
        /// <summary>
        /// Default message code
        /// </summary>
        NA,

        /// <summary>
        /// Validation : %FieldName% Already Exist @ Creation
        /// </summary>
        VLD_001,

        /// <summary>
        /// Validation : %FieldName% Already Exist @ Updation
        /// </summary>
        VLD_002,

        /// <summary>
        /// Validation : %FieldName% Does Not Exist.
        /// </summary>
        VLD_003,

        /// <summary>
        /// Validation : %FieldName% Cannot Be Marked Inactive.
        /// </summary>
        VLD_004,

        /// <summary>
        /// Validation : %FieldName% Cannot Be Deleted.
        /// </summary>
        VLD_005,

        /// <summary>
        /// Validation : %FieldName% Cannot Be Changed Due To Association.
        /// </summary>
        VLD_006,

        /// <summary>
        /// Validation : For WeightUnit and Quantity Not Provided.
        /// </summary>
        VLD_007,

        /// <summary>
        /// Validation : For WeightUnit Not Provided.
        /// </summary>
        VLD_008,

        /// <summary>
        /// Validation : For ShipperLot.
        /// </summary>
        VLD_009,

        /// <summary>
        /// Validation : For Field, Ranch and Grower Association.
        /// </summary>
        VLD_010,

        /// <summary>
        /// Validation : For Within List Name,Code,ShortName duplication.
        /// </summary>
        VLD_011,

        /// <summary>
        /// Validation : Check For Delete In Address.
        /// </summary>
        VLD_012,

        /// <summary>
        /// Validation : Record has been updated by another user.
        /// </summary>
        VLD_013,

        /// <summary>
        /// Validation : For Duplication In Field With Respect To Parent Entity.
        /// </summary>
        VLD_014,

        /// <summary>
        /// Validation : Record has been deleted by another user.
        /// </summary>
        VLD_015,

        /// <summary>
        /// Validation : Record has been marked inactive or COO.
        /// </summary>
        VLD_016,

        /// <summary>
        /// Validation : Bulk Record has been marked inactive or COO.
        /// </summary>
        VLD_017,

        /// <summary>
        /// Validation : Default Country Cannot Be Deleted.
        /// </summary>
        VLD_018,

        /// <summary>
        /// Validation : Default Country Used in My Company.
        /// </summary>
        VLD_019,

        /// <summary>
        /// Validation : Record has been marked canceled
        /// </summary>
        VLD_020,

        /// <summary>
        /// Validation : Record cannot be marked cancel due to received child
        /// </summary>
        VLD_021,

        /// <summary>
        /// Validation : Record cannot be marked cancel due to its received status
        /// </summary>
        VLD_022,

        /// <summary>
        /// Validation : Harvest Tags of only Completed Load can be received
        /// </summary>
        VLD_023,

        /// <summary>
        /// Validation : Load can be completed with complete hierarchy only
        /// </summary>
        VLD_024,

        /// <summary>
        /// Validation : Action on entity cannot be performed due to its parent status
        /// </summary>
        VLD_025,

        /// <summary>
        /// Validation :    Failed to update because of received/Completed entity
        /// </summary>
        VLD_026,

        /// <summary>
        /// Validation : Record has been marked completed
        /// </summary>
        VLD_027,

        /// <summary>
        /// Validation: Tag cannot be printed due to incomplete hierarchy
        /// </summary>
        VLD_028,

        /// <summary>
        /// Validation: Ending ITN value cannot be lower or equal to the Starting ITN
        /// </summary>
        VLD_029,

        /// <summary>
        /// Validation: Starting ITN must be smaller than Ending ITN 
        /// </summary>
        VLD_030,

        /// <summary>
        /// Validation:Cannot delete! %EntityName% is a member of a %UsedIn%.
        /// </summary>
        VLD_031,

        /// <summary>
        /// Validation: Ending ITN is out of Campaign range 
        /// </summary>
        VLD_032,

        /// <summary>
        /// Validation: Product Line with same line number is already exist for harvest tag
        /// </summary>
        VLD_033,

        /// <summary>
        /// Validation: Market Use can not be deleted because it is the only Market Use associated to this Crop.
        /// </summary>
        VLD_034,

        /// <summary>
        /// Validation: First date must be before Last date.
        /// </summary>
        VLD_035,


        // <summary>
        /// Validation: Date range overlapping.
        /// </summary>
        VLD_036,

        // <summary>
        /// Validation: Date ranges Gaps.
        /// </summary>
        VLD_037,

        /// <summary>
        /// Unhandled exception error message
        /// </summary>
        ERR_001,

        /// <summary>
        /// Un authenticated/authorized error message
        /// </summary>
        ERR_002,

        /// <summary>
        /// Error code indicated QuerySettings related errors
        /// </summary>
        ERR_003,

        // <summary>
        /// Validation: Market Use type for Change
        /// </summary>
        VLD_038,

        // <summary>
        /// Validation: Market Use type for Delete
        /// </summary>
        VLD_039,

        // <summary>
        /// Validation: Crop's Existance validation for MarketUse
        /// </summary>
        VLD_040,

        /// <summary>
        /// Changing crop's growing method from both to something else, when there exists some market use
        /// </summary>
        VLD_041,

        /// <summary>
        /// Validation: Parent's Existance validation for Child Entity 
        /// </summary>
        VLD_042,

        /// <summary>
        /// Validation : Entity has been updated by another user.
        /// </summary>
        VLD_043,

        /// <summary>
        /// Validation : Entity has been deleted by another user.
        /// </summary>
        VLD_044,

        /// <summary>
        /// Validation : Market Use is a member of cultivation group.
        /// </summary>
        VLD_045,

        /// <summary>
        /// Validation : Please activate atleast one recipient.
        /// </summary>
        VLD_046,

        /// <summary>
        /// Validation : Please activate atleast one recipient.
        /// </summary>
        VLD_047,

        /// <summary>
        /// Validation : Please activate atleast one recipient.
        /// </summary>
        VLD_048,

        /// <summary>
        /// Validation : Profile cannot be created because Entity is also associated with ProfileName
        /// </summary>
        VLD_049,

        /// <summary>
        /// Validation: In case someone try to change the parent Id of a child entity.
        /// </summary>
        VLD_050,

        /// <summary>
        /// Validation: District Delete validation Message for association with Ranch.
        /// </summary>
        VLD_051,

        /// <summary>
        /// Validation: Grower Delete validation Message for association with Ranch or Shipper Lot.
        /// </summary>
        VLD_052,

        /// <summary>
        /// Validation: %EntityName% cannot be deleted because it %ChildEntities% are associated in %ProfileName%.
        /// </summary>
        VLD_053,

        /// <summary>
        /// Validation: Cannot add User Defined Group Member if UserDefined GroupType is different to Group Member Type.
        /// </summary>
        VLD_054,

        /// <summary>
        /// Validation: Cannot update User Defined Group Member if UserDefined GroupType is different to Group Member Type.
        /// </summary>
        VLD_055,

        /// <summary>
        /// Validation: Delete validation Message for already deleted Records.
        /// </summary>
        VLD_056,

        /// <summary>
        /// Validation: Required field validation
        /// </summary>
        VLD_057,

        /// <summary>
        /// Validation : Demand uniqueness
        /// </summary>
        VLD_058,

        /// <summary>
        /// Validation : Record can not be delete due to association
        /// </summary>
        VLD_059,

        /// <summary>
        /// Validation:Harvest date beyond the ranges of growing season.
        /// </summary>
        VLD_060,

        /// <summary>
        /// Validation:Demand Lines Quantity
        /// </summary>
        VLD_061,

        /// <summary>
        /// Validation:Field cannot be changed
        /// </summary>
        VLD_062,

        /// <summary>
        /// Validation:Can not Delete Crop
        /// </summary>
        VLD_063,

        /// <summary>
        /// Validation:Demand consolidation - same Unit and Budgeted Yield profile
        /// </summary>
        VLD_064,

        /// <summary>
        /// Validation:Demand consolidation - same Market Use or Market Uses within the same Cultivation Group
        /// </summary>
        VLD_065,

        /// <summary>
        /// %EntityName% cannot be %Action% because it's the only associated member in %ParentEntity%.
        /// </summary>
        VLD_066,

        /// <summary>
        /// Validation: Market Use's Growing method can not be updated because it is shared with a Cultivation Group.
        /// </summary>
        VLD_067,


        /// <summary>
        /// Validation:	%FieldName% of %EntityName% does not match with %ParentEntity%.	Validation: Parent and Child record's particular detail doesn't match
        /// </summary>
        VLD_068,

        /// <summary>
        /// Record(s) cannot be saved, because selected %EntityName% does not contain any valid %ChildEntity%
        /// </summary>
        VLD_069,

        /// <summary>
        /// Validation:Crop[Market Use] is not a member of Budgeted Yield Profile
        /// </summary>
        VLD_070,

        /// <summary>
        /// Demand Line(s) with Harvest Date '%HarvestDate%' already exists for selected Demand.
        /// </summary>
        VLD_071,

        /// <summary>
        /// %FieldName1% and %FieldName2% are not uniqe within %EntityName%.
        /// </summary>
        VLD_072,

        /// <summary>
        /// Validation : BudgetedYieldProfile Member association.
        /// </summary>
        VLD_073,

        /// <summary>
        /// Validation: Parent Existance validation for Child record.
        /// </summary>
        VLD_074,

        /// <summary>
        /// %EntityName1% cannot be %Action%, because record(s) already exists for selected %EntityName2%.
        /// </summary>
        VLD_075,

        /// <summary>
        /// %EntityName% cannot be %Action% in %Operation% because its %FieldName1% is either not setup or not available.
        /// </summary>
        VLD_076,

        /// <summary>
        /// Validation: Parent Existance validation for Child record.
        /// </summary>
        VLD_077,

        /// <summary>
        /// Validation:Field cannot be changed
        /// </summary>
        VLD_078,

        /// <summary>
        /// Validation:Date Type and Planting Method must be compatible.
        /// </summary>
        VLD_079,

        /// <summary>
        /// Validation:Date Type and Planting Method must be compatible.
        /// </summary>
        VLD_080,

        /// <summary>
        /// Validation:Date Type and Planting Method must be compatible.
        /// </summary>
        VLD_081,

        /// <summary>
        /// Validation:One of the Fields is required.
        /// </summary>
        VLD_082,

        /// <summary>
        /// Validation:Enter value if unit is provided
        /// </summary>
        VLD_083,

        /// <summary>
        /// Validation:Select unit if value is provided
        /// </summary>
        VLD_084,

        /// <summary>
        /// Validation:Planting Method is required
        /// </summary>
        VLD_085,

        /// <summary>
        /// Validation:Invalid data
        /// </summary>
        VLD_086,

        /// <summary>
        /// Validation:Invalid association
        /// </summary>
        VLD_087,

        /// <summary>
        /// Validation:Planting Method not selected
        /// </summary>
        VLD_088,

        /// <summary>
        /// Validation:Grow Days Profile not found
        /// </summary>
        VLD_089,

        /// <summary>
        /// Validation:Range validation
        /// </summary>
        VLD_090,

        /// <summary>
        ///  %FieldName1% cannot be %Relation% than %FieldName2%, please adjust %FieldName3%.
        /// </summary>
        VLD_091,

        /// <summary>
        ///  Validation : Entity's and entity parent's field is not matching
        /// </summary>
        VLD_092,

        /// <summary>
        ///  Validation : One or more %FieldName%(s) of %EntityName%(s) do not match with %ParentEntity%'s %ProduceType%.
        /// </summary>
        VLD_093,

        /// <summary>
        ///  Validation : One or more %FieldName%(s) of %EntityName%(s) is not part of %ParentEntity%'s %ProduceType%.
        /// </summary>
        VLD_094,

        /// <summary>
        ///  Validation : Wet Date/Transplant Date was not found for the updated Harvest Date %FieldValue%
        /// </summary>
        VLD_095,

        /// <summary>
        ///  Validation : Demands cannot be consolidated because one or more Demands have Fields assigned
        /// </summary>
        VLD_096,

        /// <summary>
        ///  Please enter valid %FieldName% upto 2 decimal places between 0.50 and 10000000.00.
        /// </summary>
        VLD_097,

        /// <summary>
        ///  The %EntityName% you are removing has %AssociatedEntity% associated with it and cannot be removed, to remove the %EntityName% delete the %AssociatedEntity% first.
        /// </summary>
        VLD_098,

        /// <summary>
        ///  %FieldName% is required.
        /// </summary>
        VLD_099,

        /// <summary>
        ///  If Organic Status is %StatusName% then %FieldName% should be %Required%.
        /// </summary>
        VLD_100,

        /// <summary>
        ///  %FieldName% contains invalid value.
        /// </summary>
        VLD_101,

        /// <summary>
        ///  %EntityName% cannot be %Action% because it's one of the only two associated members in %ParentEntity%.
        /// </summary>
        VLD_102,

        /// <summary>
        /// %FieldName1% should be greater than %FieldName2%.
        /// </summary>
        VLD_103,

        /// <summary>
        /// %FieldName% of %EntityName% do not match with %ParentEntity%'s %ProduceType%.
        /// </summary>
        VLD_105,

        /// <summary>
        /// %FieldName% of %EntityName%(s) is not part of %ParentEntity%'s %ProduceType%.
        /// </summary>
        VLD_106,

        /// <summary>
        /// Please setup %PlantingMethod% for its associated grow days profile.
        /// </summary>
        VLD_107,

        /// <summary>
        /// The total assigned planting acres are greater than the field available acres. Are you sure you want to continue?
        /// </summary>
        VLD_108,

        /// <summary>
        /// The Budgeted Yield Profile doesn't have records set up, please set up yields before proceeding.
        /// </summary>
        VLD_109,

        /// <summary>
        /// Please set default planting method for %ParentEntityName%.
        /// </summary>
        VLD_110,

        /// <summary>
        /// Multiple bed widths exist for the selected profile; please select a default bed width to see available fields.
        /// </summary>
        VLD_111,

        /// <summary>
        /// Same combination of shipper and shipper lot in planting includes shipper record.
        /// </summary>
        VLD_112,

        /// <summary>
        /// Assignments cannot be removed because some of the plantings have been confirmed.
        /// </summary>
        VLD_113,

        /// <summary>
        /// Assignments cannot be removed because some of the plantings have been confirmed.
        /// </summary>
        VLD_114,

        /// <summary>
        /// Harvest Date is not found in the Grow Days Profile for the Wet Date/Transplant Date of this Planting.
        /// </summary>
        VLD_115,

        /// <summary>
        /// The Budgeted Yield Profile doesn't have records set up, please set up yields before proceeding.
        /// </summary>
        VLD_116,

        /// <summary>
        /// A valid grow days profile was not found for %MarketUse% , please setup grow days before proceeding.
        /// </summary>
        VLD_117,

        /// <summary>
        /// The Grow Days Profile doesn't have grow days setup, please setup grow days for  %MarketUse% before proceeding.       
        /// </summary>
        VLD_118
    }
}
