
//---------------------------------------------------------------------------

export default class Vote {
  constructor(options) {

    this.Id = null;
    this.Code = null;
    this.RegistrantId = null;
    this.Ballot = null;
    this.BallotCast = null;
    this.DateCreated = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.Code = options.Code || this.Code;
    this.RegistrantId = options.RegistrantId || this.RegistrantId;
    this.Ballot = options.Ballot || this.Ballot;
    this.BallotCast = options.BallotCast || this.BallotCast;
    this.DateCreated = options.DateCreated || this.DateCreated;

  }  
  //---------------------------------------------------------------------------  
}