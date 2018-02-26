export class Format {
  constructor(public idformat: number, public nume: string) {
    
  }
  
}

export class FormatView extends Format
{

  constructor(f:Format) {
    super(f.idformat, f.nume);
    this.isModified = false;
    this.isNew = false;
    this.isDeleted = false;
  }
  isModified: boolean;
  isNew: boolean;
  isDeleted: boolean;
}
