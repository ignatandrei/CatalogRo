import { ResursaDicts } from './ResursaDicts';

export class Resursa {
  constructor(public nume:string) {
    
  }
  resurse: ResursaDicts[];
}

export class ResursaView extends Resursa
{

  constructor(f: Resursa) {
    super(f.nume);
    this.isModified = false;
    this.isNew = false;
    this.isDeleted = false;
  }
  isModified: boolean;
  isNew: boolean;
  isDeleted: boolean;
}
