import { Component, inject, OnInit, signal } from '@angular/core';
import { SolicitorService } from '../../services/solicitor.service';
import { NationalReport } from '../../models/national-report.model';

@Component({
  selector: 'app-report.component',
  imports: [],
  templateUrl: './report.component.html',
  styleUrl: './report.component.scss',
})
export class ReportComponent implements OnInit {

  private solicitorService = inject(SolicitorService);
  reportData: NationalReport | null = null;
  isLoading = signal(false);

  ngOnInit() {
    this.isLoading.set(true)    ;
    this.solicitorService.fetchReport().subscribe({
      next: (report) => {
        this.reportData = report;
      },
      complete: () => {
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Failed to fetch report:', err);
      }
    });

  }
}
