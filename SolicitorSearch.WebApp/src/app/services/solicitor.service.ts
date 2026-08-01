import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Solicitor } from '../models/solicitor.model';
import { NationalReport } from '../models/national-report.model';

@Injectable({
  providedIn: 'root'
})
export class SolicitorService {

  private http = inject(HttpClient);

  private readonly baseUrl = 'http://localhost:5059/';

  searchByLocation(location: string): Observable<Solicitor[]> {
    return this.http.get<Solicitor[]>(`${this.baseUrl}solicitorApi/${location}`);
  }

  fetchReport(): Observable<NationalReport> {
    return this.http.get<NationalReport>(`${this.baseUrl}solicitorApi/report`);
  }

}