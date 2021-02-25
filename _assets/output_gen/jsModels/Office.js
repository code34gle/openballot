
//---------------------------------------------------------------------------

export default class Office {
  constructor(options) {

    this.Id = null;
    this.Name = null;
    this.Description = null;
    this.DateCreated = null;
    this.DateUpdated = null;
    this.UpdatedBy = null;
    this.Candidates = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.Name = options.Name || this.Name;
    this.Description = options.Description || this.Description;
    this.DateCreated = options.DateCreated || this.DateCreated;
    this.DateUpdated = options.DateUpdated || this.DateUpdated;
    this.UpdatedBy = options.UpdatedBy || this.UpdatedBy;
    this.Candidates = options.Candidates || this.Candidates;

  }  
  //---------------------------------------------------------------------------  
}