import { Component, OnInit } from '@angular/core';
import { FormatService } from '../format.service';
import { Observable } from 'rxjs/Observable';
import { Format } from '../format';

@Component({
  selector: 'app-formats',
  templateUrl: './formats.component.html',
  styleUrls: ['./formats.component.css']
})
export class FormatsComponent implements OnInit {

  formats: Format[];
  constructor(private formatService: FormatService) { }
  getFormats(): void {
    this.formatService.getFormats().subscribe(it => this.formats = it);
  }
  ngOnInit() {
    this.getFormats();
  }

}
