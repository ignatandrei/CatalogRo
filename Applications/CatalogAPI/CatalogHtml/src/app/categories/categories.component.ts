import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../category.service';
import { Observable } from 'rxjs/Observable';
import { Category, CategoryView } from '../category';
//import 'rxjs/add/operator/map'
import 'rxjs/Rx'

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  lists: CategoryView[];
  constructor(private service: CategoryService) { }
  getList(): void {
    
    this.service.getList()
      .map(function (a, b) {
        return a.map(it => {
          var t = new CategoryView(it);
          t.isNew = false;
          t.isModified = false;
          return t;
        }
        )
      })
      .subscribe(it => this.lists = it);

  }
  ngOnInit() {
    this.getList();
  }
  save(): void {
    console.log('save0');
    var toSave = this.lists.filter(it => it.isModified);
    if (toSave.length == 0)
      return;

    console.log('save1');
    var saved = this.service.save(toSave.filter(it => !it.isDeleted));
    var deleted = this.service.delete(toSave.filter(it => it.isDeleted));
    console.log('save2');

    Observable
      .merge([saved, deleted])
      .switchMap((e) => { return e })
      .subscribe(() => this.getList());


  }
  haveChanges(): boolean {
    if ((this.lists || []).length < 1)
      return false;

    return this.lists.some(it => it.isModified);
  }
  addNew(): void {
    this.lists.push(new CategoryView(new Category(0, "", 0)));
  }
  delete(f: CategoryView, op: boolean) {
    f.isDeleted = op;
  }


}
