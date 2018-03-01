import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
//import 'rxjs/add/operator/map'
import 'rxjs/Rx'
import { Format } from './format'
import { HttpClientModule,HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class FormatService {
  private formatsUrl = '/api/Formats';
  constructor(private http: HttpClient) { }
  save(data: Format[]): Observable<Format[]> {
    if ((data || []).length == 0)
      return Observable.of([]);

    return this.http.post<Format[]>(this.formatsUrl, data);
  }
  delete(data: Format[]): Observable<Format[]> {
    if ((data || []).length == 0) {
      //var arr = new Array<Format>();
      return Observable.of([]);
    }
    //const url = `${this.heroesUrl}/${id}`;
    var str= data
        .map((it, i, all) => `${this.formatsUrl}/${it.idformat}`)
      .map(it => this.http.delete<Format[]>(it))
      
    return Observable.merge(str).switchMap((e) => { return e });
    
    
      

  }
  getFormats(): Observable<Format[]> {
    
    return this.http.get<Format[]>(this.formatsUrl);
    
          
  }

}
