import { LocationReport } from "./location-report.model";
import { Solicitor } from "./solicitor.model";

export interface NationalReport {
    locationReports: LocationReport[];
    topSolicitors: Solicitor[];
}