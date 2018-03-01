export class Category {
  constructor(public idcategorie: number, public nume: string, public parent:number) {
    
  }
  
}

export class CategoryView extends Category
{

  constructor(c: Category) {
    super(c.idcategorie, c.nume,c.parent);
    this.isModified = false;
    this.isNew = false;
    this.isDeleted = false;
  }
  isModified: boolean;
  isNew: boolean;
  isDeleted: boolean;
}
