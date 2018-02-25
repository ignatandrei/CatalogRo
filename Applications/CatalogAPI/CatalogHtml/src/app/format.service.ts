import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
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

  getFormats(): Observable<Format[]> {
    //return of([
    //  { id: 11, name: 'Mr. Nice' },
    //  { id: 12, name: 'Narco' }
    //]);
    return this.http.get<Format[]>(this.formatsUrl);
  }

}
