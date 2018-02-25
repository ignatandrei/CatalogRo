import { Component, OnInit, Input } from '@angular/core';
import { Format } from "../format"

@Component({
  selector: 'app-format',
  templateUrl: './format.component.html',
  styleUrls: ['./format.component.css']
})
export class FormatComponent implements OnInit {

  @Input() format: Format;

  constructor() { }

  ngOnInit() {
    
  }

}
