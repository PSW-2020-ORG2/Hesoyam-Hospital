import { SchedulingStartedEvent } from './scheduling-started-event';

describe('SchedulingStartedEvent', () => {
  it('should create an instance', () => {
    expect(new SchedulingStartedEvent()).toBeTruthy();
  });
});
