# Github Action
- Github에서 제공하는 CI (지속적 통합) 를 위한 툴
- 각각의 개발자가 개발한 코드를 하나의 저장소에서 통합하는 과정(?)
- 정적분석, 단위 테스트, 분석결과 리포팅, 배포 서버에 push 하는 등의 여러 작업을 수행
- 배포 전에 한 번에 모아서 통합하는 것이 아닌 조금씩 자주 통합해 나가는 과정(?)

### Workflow
- github repository에 대해 일련의 작업들을 수행하는 자동화된 프로세스. 저장소 root에 ./github/workflows/아래에 정의된 .yml 설정 파일 필요

### Event
- workflow가 실행 되도록 만드는 trigger. push, pull request가 있음.

### Job
- 여러개의 step으로 이루어질 수 있으며 단일한 가상 환경을 가짐

### Step
- job안에서 순차적으로 실행되는 프로세스 단위


### 참고
- https://blog.aliencube.org/ko/2019/12/18/building-ci-cd-pipelines-with-github-actions/
