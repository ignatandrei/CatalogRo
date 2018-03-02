import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Resursa } from '../resursa'
import { ResursaDictsService } from '../resursa.service'
@Component({
  selector: 'app-resursa',
  templateUrl: './resursa.component.html',
  styleUrls: ['./resursa.component.css']
})
export class ResursaComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private resursaDictService: ResursaDictsService,
    private location: Location) {
    this.resursa = new Resursa("Resursa");
  }

  resursa: Resursa;

  ngOnInit() {
    
    this.getResurse();
  }
  getResurse(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.loaded = false;
    this.resursaDictService.getResursa(id, this.resursa.nume)
      .subscribe(all => {
        all.forEach(it => it.valoaredata = "asdad" + it.valoare);
        this.resursa.resurse = all;
        
        this.loaded = true;
      });
  }
  loaded: boolean = false;
  save(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.resursaDictService.saveResursa(id, this.resursa)
      .subscribe(all => {
        console.log('a' + all);
        location.href = '/adddata/resurse';
      });
  }
}
