import { Component, OnInit } from '@angular/core';
import { Resursa } from '../resursa'
import { ResursaDicts } from '../ResursaDicts'
import { ResursaDictsService } from '../resursa.service'
import { of } from 'rxjs/observable/of';
//import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx'
import 'rxjs/add/observable/from';
import { catchError, map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-resurse',
  templateUrl: './resurse.component.html',
  styleUrls: ['./resurse.component.css']
})
export class ResurseComponent implements OnInit {

  constructor(private resursaDictService: ResursaDictsService) { }
  resurse: ResursaDicts[];
  groupedResurses: Map<Date, ResursaDicts[]>;
  
  ngOnInit() {
    this.getResurseForUser();
  }
  loaded: boolean = false;
  getResurseForUser(): void {
    this.loaded = false;
    this.groupedResurses = new Map<Date, ResursaDicts[]>();
    const idUser = 1;
    
    this.resursaDictService.getResursaForUser(idUser)
      .subscribe(all => {        
        this.resurse = all;
        //TODO:make unique
        const t = Observable.from(
          all.sort((x, y) => {
            if (y.dataIntroducere > x.dataIntroducere)
              return 1;
            if (y.dataIntroducere === x.dataIntroducere)
              return 0;
            return -1;
            }
            ))
          .groupBy(
          it => it.dataIntroducere
        ).subscribe(it => {
          let arr: ResursaDicts[]= new Array<ResursaDicts>();
          this.groupedResurses.set(it.key,arr );
          it.subscribe(r => arr.push(r));
          this.loaded = true;
          });
      });
    
  }

}
