import { Component, OnChanges, SimpleChanges, SimpleChange, OnInit, DoCheck, Input, KeyValueDiffers, KeyValueDiffer } from '@angular/core';
import { Category, CategoryView} from '../category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit, DoCheck {

  private _itemToDisplay: CategoryView;
  private _initialValue: CategoryView;
  @Input()
  set itemToDisplay(value: CategoryView) {
    if (!this._initialValue && value) {
      //clone
      this._initialValue = Object.assign({}, value);
      //this.differ = this.differs.find(this._initialValue).create();
      //console.log('created differ '+ value.idformat);
    }
    this._itemToDisplay = value;

  }

  get itemToDisplay(): CategoryView {
    return this._itemToDisplay;

  }
  isNew: boolean = false;
  private _isModified: boolean = false;

  get isModified(): boolean {
    return this._isModified;
  }
  set isModified(value: boolean) {
    this._isModified = value;
    if (this._itemToDisplay)
      this._itemToDisplay.isModified = value;

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


  ngDoCheck() {

    this.isModified =
      (this._itemToDisplay.nume != this._initialValue.nume)
    ||
    (this._itemToDisplay.parent != this._initialValue.parent)
      ||
    (this._itemToDisplay.isDeleted != this._initialValue.isDeleted);
  }
}
