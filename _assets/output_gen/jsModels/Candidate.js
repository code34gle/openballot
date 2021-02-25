
//---------------------------------------------------------------------------

export default class Candidate {
  constructor(options) {

    this.Id = null;
    this.OfficeId = null;
    this.FirstName = null;
    this.MiddleName = null;
    this.LastName = null;
    this.Party = null;
    this.IsSelected = null;
    this.IsIncumbant = null;
    this.DateCreated = null;
    this.DateUpdated = null;
    this.UpdatedBy = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.OfficeId = options.OfficeId || this.OfficeId;
    this.FirstName = options.FirstName || this.FirstName;
    this.MiddleName = options.MiddleName || this.MiddleName;
    this.LastName = options.LastName || this.LastName;
    this.Party = options.Party || this.Party;
    this.IsSelected = options.IsSelected || this.IsSelected;
    this.IsIncumbant = options.IsIncumbant || this.IsIncumbant;
    this.DateCreated = options.DateCreated || this.DateCreated;
    this.DateUpdated = options.DateUpdated || this.DateUpdated;
    this.UpdatedBy = options.UpdatedBy || this.UpdatedBy;

  }  
  //---------------------------------------------------------------------------  
}