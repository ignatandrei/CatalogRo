import { Component, OnInit } from '@angular/core';
import { Resursa } from '../resursa'
import { ResursaDicts } from '../ResursaDicts'
import { ResursaDictsService } from '../resursa.service'

@Component({
  selector: 'app-resurse',
  templateUrl: './resurse.component.html',
  styleUrls: ['./resurse.component.css']
})
export class ResurseComponent implements OnInit {

  constructor(private resursaDictService: ResursaDictsService) { }
  resurse: ResursaDicts[]=[];

  ngOnInit() {
    this.getResurseForUser();
  }
  loaded: boolean = false;
  getResurseForUser(): void {
    const idUser = 1;
    this.loaded = false;
    this.resursaDictService.getResursaForUser(idUser)
      .subscribe(all => {        
        this.resurse= all;
        this.loaded = true;
      });
  }

}
