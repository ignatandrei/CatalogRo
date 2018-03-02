import { Component, OnInit } from '@angular/core';
import { FormatService } from '../format.service';
import { Observable } from 'rxjs/Observable';
import { Format , FormatView} from '../format';
//import 'rxjs/add/operator/map'
import 'rxjs/Rx'
@Component({
  selector: 'app-formats',
  templateUrl: './formats.component.html',
  styleUrls: ['./formats.component.css']
})
export class FormatsComponent implements OnInit {

  loading: boolean;
  formats: FormatView[];
  constructor(private formatService: FormatService) { }
  getFormats(): void {
	  this.loading=true;
    this.formatService.getFormats()
      .map(function (a, b) {
        return a.map(it => {
          var t = new FormatView(it);
          t.isNew = false;
          t.isModified = false;
          return t;
        }
          )
      })
    .subscribe(it => {
		    this.formats = it;
        this.loading = false;
	  });
      
  }
  ngOnInit() {
    this.getFormats();
  }
  save(): void {
    console.log('save0');
    var toSave = this.formats.filter(it => it.isModified);
    if (toSave.length == 0)
      return;

    console.log('save1');
    var saved = this.formatService.save(toSave.filter(it=>!it.isDeleted));
    var deleted = this.formatService.delete(toSave.filter(it => it.isDeleted));
    console.log('save2');
    //saved.subscribe(() => this.getFormats());
    //deleted.subscribe(() => this.getFormats());
    Observable
      .merge([saved, deleted])
      .switchMap((e) => { return e })
      .delay(2000)
      .subscribe(() => this.getFormats());

      
  }
  haveChanges(): boolean{
    if ((this.formats||[]).length < 1)
      return false;

    return this.formats.some(it=>it.isModified);
  }
  addNew(): void {    
    this.formats.push(new FormatView(new Format(0,"")));
  }
  delete(f: FormatView, op:boolean) {
    f.isDeleted = op;
  }


}
