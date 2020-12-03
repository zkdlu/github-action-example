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


## 뇌피셜 (검증 필요)
1. 프로젝트에서 공통으로 사용하는 라이브러리같은 경우 nuget이나 gradle, npm 같은 패키지 매니저에서 참조하여 사용함.
2. 그래서 패키지가 변경 되면 빌드하고 패키지 매니저에 업로드를 해야 함.
3. CI 툴은 이런 행위를 일련의 workflow로 자동화 함.

## .NET Core에서 사용해보기
### 1. Nuget에 패키지 수동으로 업로드 하기
1. 클래스 라이브러리 프로젝트를 만든 후, .csproj 파일에 패키지 메타데이터 추가
    ```.csproj
    <PropertyGroup>
      <PackageId>DemoLib</PackageId>
      <Version>0.0.1</Version>
      <Author>zkdlu</Author>
      <Company>zkdlu</Company>
    </PropertyGroup>
    ```

## Java에서 해보기
