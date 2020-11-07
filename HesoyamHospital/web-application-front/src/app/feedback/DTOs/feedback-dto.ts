export class FeedbackDTO {

    public constructor(
        public comment: string,
        public anonymity: boolean,
        public visibility: boolean
    ) {}
    
}
