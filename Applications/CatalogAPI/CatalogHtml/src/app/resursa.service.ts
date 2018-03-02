import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
//import 'rxjs/add/operator/map'
import 'rxjs/Rx'
import { ResursaDicts } from './resursadicts'
import { Resursa} from './resursa'
import { HttpClientModule,HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class ResursaDictsService {
  private linkUrl = '/api/ResursaDicts';
  private linkUrlSave = '/api/ResursaValoares';
  constructor(private http: HttpClient) {
    //  this.linkUrl += '/'+id;
  }
  //save(data: ResursaDicts[]): Observable<ResursaDicts[]> {
  //  if ((data || []).length == 0)
  //    return Observable.of([]);

  //  return this.http.post<Format[]>(this.formatsUrl, data);
  //}
  //delete(data: Format[]): Observable<Format[]> {
  //  if ((data || []).length == 0) {
  //    //var arr = new Array<Format>();
  //    return Observable.of([]);
  //  }
  //  //const url = `${this.heroesUrl}/${id}`;
  //  var str= data
  //      .map((it, i, all) => `${this.formatsUrl}/${it.idformat}`)
  //    .map(it => this.http.delete<Format[]>(it))
      
  //  return Observable.merge(str).switchMap((e) => { return e });
    
    
      

  //}
  private getList(nume:string): Observable<ResursaDicts[]> {

    const url = this.linkUrl + '/' + nume;
    return this.http.get<ResursaDicts[]>(url);              
  }
  private saveNewList(resursa: Resursa): Observable<number> {

    const url = this.linkUrlSave + '/' + resursa.nume;
    return this.http.post<number>(url,resursa.resurse);
  }
  getResursa(id: number|string, nume: string): Observable<ResursaDicts[]> {
    if (id == 0) {
      return this.getList(nume);
    }
    return null;
  }
  saveResursa(id: number | string, resursa: Resursa): Observable<number>{
    if (id == 0) {
      return this.saveNewList(resursa);
    }
  }
}
