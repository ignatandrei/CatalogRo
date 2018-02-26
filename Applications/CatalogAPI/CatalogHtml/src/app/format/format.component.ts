import { Component, OnChanges, SimpleChanges,SimpleChange, OnInit, DoCheck, Input, KeyValueDiffers ,KeyValueDiffer } from '@angular/core';
import { Format, FormatView} from "../format"

@Component({
  selector: 'app-format',
  templateUrl: './format.component.html',
  styleUrls: ['./format.component.css']
})
//https://angular.io/guide/lifecycle-hooks#onchanges
export class FormatComponent implements  OnInit, DoCheck/*, OnChanges */{
  //ngOnChanges(changes: SimpleChanges): void {
  //  console.log('on changes');
  //  for (let propName in changes) {
  //    let change = changes[propName];

  //    let curVal = JSON.stringify(change.currentValue);
  //    let prevVal = JSON.stringify(change.previousValue);
  //    let changeLog = `${propName}: currentValue = ${curVal}, previousValue = ${prevVal}`;

  //    console.log(changeLog);
  //  }

  //}


  private _format: FormatView;
  private _initialValue: FormatView;
  @Input()
  set format(value: FormatView) {
    if (!this._initialValue && value) {
      //clone
      this._initialValue = Object.assign({}, value);
      //this.differ = this.differs.find(this._initialValue).create();
      //console.log('created differ '+ value.idformat);
    }
    this._format = value;

  }

  get format(): FormatView {
    return this._format;

  }

  isNew: boolean=false;
  private _isModified: boolean = false;

  get isModified(): boolean {
    return this._isModified;
  }
  set isModified(value: boolean) {
    this._isModified = value;
    if (this._format)
      this._format.isModified = value;

    this.setCurrentStyles();
  }

  
  differ: any;
  constructor(private differs: KeyValueDiffers) {
    this.isModified = false;
    
  }

  ngOnInit() {

  }
  

  currentStyles: {};
  setCurrentStyles() {

    // CSS styles: set per current state of component properties
    this.currentStyles = {
      'font-style': this.isModified ? 'italic' : 'normal',
      'font-weight': !this.isModified ? 'bold' : 'normal',
      'font-size': this.isModified ? '24px' : '12px'
    };
  }

  //doSomething(): void {

  //  var changes = this.differs.find(this._initialValue).create();
  //  var d= changes.diff(this._format);
  //  this.isModified = (changes) ? true :false;
  //  if (this._format.idformat != 1)
  //    return;
  //  if (changes) {
  //    console.log('changes detected for ' + this._format.idformat);
  //    changes.forEachChangedItem(r => console.log('changed to ', r.currentValue, ' from ' ));
  //    changes.forEachAddedItem(r => console.log('added ' + r.currentValue));
  //    changes.forEachRemovedItem(r => console.log('removed ' + r.currentValue));
  //  } else {
  //    console.log('nothing changed for ' + this._format.idformat);    
  //  }
  //}
  ngDoCheck() {
    //console.log('do check');
    this.isModified =
      (this._format.nume != this._initialValue.nume)
      ||
      (this._format.isDeleted != this._initialValue.isDeleted);

    //console.log(this._format.nume != this._initialValue.nume);
    //console.log(this._format.isDeleted , this._initialValue.isDeleted);
    //if (this._format.idformat != 1)
    //  return;
    //console.log(this._initialValue.nume);
    
    //const changes = this.differ.diff(this._format);
    
    //if (changes) {
    //  this.isModified = true;
    //  console.log('changes detected for ' + this._format.idformat);
    //  changes.forEachChangedItem(r => console.log('changed ', r.currentValue , ' from ' , r.previousValue));
    //  changes.forEachAddedItem(r => console.log('added ' + r.currentValue));
    //  changes.forEachRemovedItem(r => console.log('removed ' + r.currentValue));
    //} else {
    //  console.log('nothing changed for ' + this._format.idformat);
    //  this.isModified = false;

    //}

  }
}
