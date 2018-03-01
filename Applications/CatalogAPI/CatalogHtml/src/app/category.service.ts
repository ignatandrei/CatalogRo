import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
//import 'rxjs/add/operator/map'
import 'rxjs/Rx'
import { Category } from './category'
import { HttpClientModule,HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class CategoryService {
  private formatsUrl = '/api/Categories';
  constructor(private http: HttpClient) { }
  save(data: Category[]): Observable<Category[]> {
    if ((data || []).length == 0)
      return Observable.of([]);

    return this.http.post<Category[]>(this.formatsUrl, data);
  }
  delete(data: Category[]): Observable<Category[]> {
    if ((data || []).length == 0) {
      //var arr = new Array<Format>();
      return Observable.of([]);
    }
    //const url = `${this.heroesUrl}/${id}`;
    var str= data
        .map((it, i, all) => `${this.formatsUrl}/${it.idcategorie}`)
      .map(it => this.http.delete<Category[]>(it))
      
    return Observable.merge(str).switchMap((e) => { return e });
    
    
      

  }
  getList(): Observable<Category[]> {

    return this.http.get<Category[]>(this.formatsUrl)
      //.pipe(
      //      tap(f =>
      //            f.forEach(it => it.isModified = false)
      //          ))
          ;
  }

}
