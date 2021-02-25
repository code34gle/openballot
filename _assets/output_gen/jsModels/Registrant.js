
//---------------------------------------------------------------------------

export default class Registrant {
  constructor(options) {

    this.Id = null;
    this.EncKey = null;
    this.Code = null;
    this.FirstName = null;
    this.MiddleName = null;
    this.LastName = null;
    this.Suffix = null;
    this.DOB = null;
    this.SSN = null;
    this.StateIdNumber = null;
    this.Street1 = null;
    this.Street2 = null;
    this.City = null;
    this.StateCode = null;
    this.PostalCode = null;
    this.DateCreated = null;
    this.DateUpdated = null;
    this.DateVerified = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.EncKey = options.EncKey || this.EncKey;
    this.Code = options.Code || this.Code;
    this.FirstName = options.FirstName || this.FirstName;
    this.MiddleName = options.MiddleName || this.MiddleName;
    this.LastName = options.LastName || this.LastName;
    this.Suffix = options.Suffix || this.Suffix;
    this.DOB = options.DOB || this.DOB;
    this.SSN = options.SSN || this.SSN;
    this.StateIdNumber = options.StateIdNumber || this.StateIdNumber;
    this.Street1 = options.Street1 || this.Street1;
    this.Street2 = options.Street2 || this.Street2;
    this.City = options.City || this.City;
    this.StateCode = options.StateCode || this.StateCode;
    this.PostalCode = options.PostalCode || this.PostalCode;
    this.DateCreated = options.DateCreated || this.DateCreated;
    this.DateUpdated = options.DateUpdated || this.DateUpdated;
    this.DateVerified = options.DateVerified || this.DateVerified;

  }  
  //---------------------------------------------------------------------------  
}